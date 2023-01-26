﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO.Models
{
    public class Candidature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PostName { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime ModificationDate { get; set; }
        [Required]
        public string Status { get; set; } = String.Empty;
        public string Comment { get; set; } = String.Empty;
        [Required]
        public Entreprise? Entreprise { get; set; }
        public ApplicationUser linkedUser { get; set; }
        public Candidature()
        {

        }

        public Candidature(string postName, DateTime modificationDate, string status, string comment)
        {
            PostName = postName;
            ModificationDate = modificationDate;
            Status = status;
            Comment = comment;
        }
    }
}

