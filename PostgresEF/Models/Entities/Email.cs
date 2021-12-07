﻿using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}