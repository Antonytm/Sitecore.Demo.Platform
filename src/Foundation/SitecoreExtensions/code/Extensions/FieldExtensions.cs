﻿using System;
using Sitecore.Data.Fields;
using Sitecore.Links.UrlBuilders;
using Sitecore.Resources.Media;

namespace Sitecore.Demo.Platform.Foundation.SitecoreExtensions.Extensions
{
    public static class FieldExtensions
    {
        public static string ImageUrl(this ImageField imageField)
        {
            if(imageField == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            if (imageField.MediaItem == null)
            {
                //empty image field
                return string.Empty;
            }

            var options = MediaUrlBuilderOptions.Empty;
            int width, height;

            if (int.TryParse(imageField.Width, out width))
            {
                options.Width = width;
            }

            if (int.TryParse(imageField.Height, out height))
            {
                options.Height = height;
            }
            return imageField.ImageUrl(options);
        }

        public static string ImageUrl(this ImageField imageField, MediaUrlBuilderOptions options)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            return options == null ? imageField.ImageUrl() : HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageField.MediaItem, options));
        }

        public static bool IsChecked(this Field checkboxField)
        {
            if (checkboxField == null)
            {
                throw new ArgumentNullException(nameof(checkboxField));
            }

            return MainUtil.GetBool(checkboxField.Value, false);
        }
    }
}
