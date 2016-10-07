﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LaptopListingSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using LaptopListingSystem.Data.Models.Common.Contracts;

    public class User : IdentityUser, IDeletableEntity
    {
        private ICollection<Comment> comments;

        public User()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
