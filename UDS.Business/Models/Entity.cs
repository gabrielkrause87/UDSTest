using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UDS.Business.Models
{
    public abstract class Entity
    {
        protected Entity() { }
        [Key]
        public int Id { get; set; }
    }
}
