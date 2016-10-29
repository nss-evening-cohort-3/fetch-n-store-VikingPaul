using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FetchNStore.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public string StatusCode { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string ResponseTime { get; set; }
        [Required]
        public string Method { get; set; }
    }
}