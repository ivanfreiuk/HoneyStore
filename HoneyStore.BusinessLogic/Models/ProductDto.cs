﻿using HoneyStore.DataAccess.Entities;

namespace HoneyStore.BusinessLogic.Models
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Mark { get; set; }

        public int Quantity { get; set; }

        public bool CommentsEnabled { get; set; }

        public int ProducerId { get; set; }

        public ProducerDto Producer { get; set; }

        public int? ProductPhotoId { get; set; }

        public ProductPhotoDto ProductPhoto { get; set; }

        public ICollection<CommentDto> Comments { get; set; }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}
