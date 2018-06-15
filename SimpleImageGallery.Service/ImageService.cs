using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleImageGallery.Service
{
    public class ImageService : IImage
    {
        public readonly SimpleImageGalleryDbContext _ctx;

        public ImageService(SimpleImageGalleryDbContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        ///  The methods below with be passed to the controller for greater user functionality
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
