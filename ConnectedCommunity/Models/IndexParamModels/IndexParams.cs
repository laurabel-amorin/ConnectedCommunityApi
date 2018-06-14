using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic.Core;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public enum ActivationState
    {
        active, inactive, all
    }
    public abstract class IndexParams<T>
    {
        public string sort { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SortDirection sort_direction { get; set; }
        public string search { get; set; }
        public string search_field { get; set; }
        public int page { get; set; } = 1;
        public int page_size { get; set; }
        public int data_size { get; set; }
        public int total_data_size { get; set; }
        public int total_pages { get; set; }

        protected abstract int GetOffset();

        protected void VerifyPageSize()
        {
            if (page_size == 0)
            {
                int pageSize = 0;
                string defaultPageSize = "20";
                if (!int.TryParse(defaultPageSize, out pageSize))
                {
                    page_size = 20;
                }
                else
                {
                    page_size = pageSize;
                }
            }
        }

        protected void SetTotalPages()
        {
            total_pages = (int)Math.Ceiling(total_data_size / (page_size * 1.0));
            if (total_pages == 0)
            {
                total_pages = 1;
            }
        }
    }

    public abstract class StandardRepoIndexParams<T> : IndexParams<T>
    {
        public abstract IQueryable<T> ApplyParams(IQueryable<T> data);

        protected IQueryable<T> ApplySearchOptions(IQueryable<T> data)
        {
            if (string.IsNullOrEmpty(search))
            {
                return data;
            }

            return ApplySearch(data);
        }

        private IQueryable<T> ApplySearch(IQueryable<T> data)
        {
            string lowercaseSearch = search.ToLower();
            var properties = typeof(T).GetProperties();
            if (!string.IsNullOrEmpty(search_field))
            {
                var searchAttribute = properties.FirstOrDefault(
                p =>
                    p.Name.Equals(search_field, StringComparison.OrdinalIgnoreCase) &&
                    Attribute.IsDefined(p, typeof(SearchableAttribute)));
                if (searchAttribute != null)
                {
                    return data.Where(GetSearchQuery(searchAttribute), lowercaseSearch);
                }

            }
            var searchAttributes = properties.Where(
                p => Attribute.IsDefined(p, typeof(SearchableAttribute)));
            var searchQueries = new List<string>();
            foreach (var searchField in searchAttributes)
            {
                searchQueries.Add(GetSearchQuery(searchField));
            }

            return data.Where(string.Join(" || ", searchQueries), lowercaseSearch);
        }

        private string GetSearchQuery(PropertyInfo searchAttribute)
        {
            if (searchAttribute.PropertyType == typeof(string))
            {
                return searchAttribute.Name + ".ToLower().Contains(@0)";
            }
            return searchAttribute.Name + ".ToString().ToLower().Contains(@0)";
        }

        protected override int GetOffset()
        {
            return page > 1 ? ((page - 1) * page_size) : 0;
        }

        private void VerifySortOptions()
        {
            var properties = typeof(T).GetProperties();
            var sortAttribute = properties.FirstOrDefault(
                p =>
                    p.Name.Equals(sort, StringComparison.OrdinalIgnoreCase) &&
                    Attribute.IsDefined(p, typeof(SortableAttribute)));
            if (sortAttribute == null)
            {
                var defaultSortable =
                    properties.FirstOrDefault(p => Attribute.IsDefined(p, typeof(DefaultSortableAttribute)));
                if (defaultSortable != null)
                {
                    sort = defaultSortable.Name;
                }
                else
                {
                    sort = properties.First().Name;
                }
            }
            else
            {
                sort = sortAttribute.Name;
            }


        }

        protected IQueryable<T> ApplySortAndPaging(IQueryable<T> data, string systemSort = null, SortDirection systemSortDirection = SortDirection.asc)
        {
            VerifyPageSize();
            VerifySortOptions();
            SetDataSizeProperties(data);
            if (string.IsNullOrEmpty(systemSort))
            {
                data = data.OrderBy($"{sort} {sort_direction}").Skip(GetOffset()).Take(page_size);
            }
            else
            {
                data = data.OrderBy($"{systemSort} {systemSortDirection}, {sort} {sort_direction}").Skip(GetOffset()).Take(page_size);
            }

            data_size = data.Count();
            return data;
        }

        protected void SetDataSizeProperties(IQueryable<T> data)
        {
            total_data_size = data.Count();
            SetTotalPages();
        }

    }

}

