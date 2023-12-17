﻿using BookActivity.Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookActivity.Domain.Models
{
    public sealed class AppUser : IdentityUser<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Relation of user with the subscribers info
        /// </summary>
        public ICollection<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// Relation of user with the subscriptions info
        /// </summary>
        public ICollection<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Relation of user with the book opinios
        /// </summary>
        public IEnumerable<BookOpinion> BookOpinions { get; set; }

        /// <summary>
        /// Relation of user with the notifications
        /// </summary>
        public ICollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Relation of user with the active books
        /// </summary>
        public ICollection<ActiveBook> ActiveBooks { get; set; }

        /// <summary>
        /// User avatar
        /// </summary>
        public byte[] AvatarImage { get; set; }

        public AppUser() : base()
        {
            
        }
    }
}