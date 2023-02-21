﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.User.RequestModel
{
    public class CreateUserRequest
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string WalletAddress { get; set; }
    }
    public class UserRequestModel
    {
        [Required]
        public int Id { get; set; }
    }
}
