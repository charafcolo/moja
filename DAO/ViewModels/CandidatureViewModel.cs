﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAO.Models
{
    public class CandidatureViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PostName { get; set; } = String.Empty;
        [Required]
        public DateTime ModificationDate { get; set; }
        [Required]
        public string Status { get; set; } = String.Empty;
        public string Comment { get; set; } = String.Empty;
        [Required]
        public Entreprise Entreprise { get; set; }
        public CandidatureViewModel()
        {

        }

        public CandidatureViewModel(int id, string postName, DateTime modificationDate, string status, string comment, Entreprise entreprise)
        {
            Id = id;
            PostName = postName;
            ModificationDate = modificationDate;
            Status = status;
            Comment = comment;
            Entreprise = entreprise;
        }
    }
}

