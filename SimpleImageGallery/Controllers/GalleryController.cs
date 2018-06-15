using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using SimpleImageGallery.Models;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            //var hikingImageTags = new List<ImageTag>()
            //{

            //};

            //var cityImageTags = new List<ImageTag>()
            //{

            //};

            //var tag1 = new ImageTag()
            //{
            //    Description = "Adventure",
            //    Id = 0
            //};
            //var tag2 = new ImageTag()
            //{
            //    Description = "Urban",
            //    Id = 1
            //};
            //var tag3 = new ImageTag()
            //{
            //    Description = "New York",
            //    Id = 2
            //};

            //hikingImageTags.Add(tag1);
            //cityImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

            //var imageList = new List<GalleryImage>()
            //{
            //    new GalleryImage()
            //    {
            //        Title = "Hiking Trip",
            //        Url = "https://www.pexels.com/photo/silhouette-photography-of-person-standing-on-green-grass-in-front-of-mountains-during-golden-hour-746386/",
            //        Created = DateTime.Now,
            //        Tags = hikingImageTags
            //    },
            //    new GalleryImage()
            //    {
            //        Title = "On the trail",
            //        Url = "https://www.pexels.com/photo/men-s-blue-leather-jacket-and-brown-backpack-868097/",
            //        Created = DateTime.Now,
            //        Tags = hikingImageTags
            //    },
            //    new GalleryImage()
            //    {
            //        Title = "Downtown",
            //        Url = "https://www.pexels.com/photo/aerial-architectural-design-architecture-buildings-373912/",
            //        Created = DateTime.Now,
            //        Tags = cityImageTags
            //    }
            //};
            
            var imageList = _imageService.GetAll();

            var model = new GalleryIndexModel
            {
                Images = imageList,
                SearchQuery = ""
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            // Use the service to retrieve the image by it's ID
            var image = _imageService.GetById(id);

            // Push that into the view-model
            var model = new GalleryDetailModel()
            {
                Id = image.Id,
                Title = image.Title,
                CreatedOn = image.Created,
                Url = image.Url,
                // Dump the collection of tags and return them as a list
                Tags = image.Tags.Select(t => t.Description).ToList()
            };

            return View(model);
        }
    }
}