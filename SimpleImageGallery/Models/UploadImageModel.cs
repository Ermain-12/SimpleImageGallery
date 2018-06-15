using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleImageGallery.Models
{
    public class UploadImageModel
    {
        public string Title { get; set; }

        // The user will specify comma-seperated tags
        public string Tags { get; set; }

        // Represents the form which the user will fill
        public IFormFile ImageUpload { get; set; }
    }
}
