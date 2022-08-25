using System;

namespace DaghanDigital.Core.Models
{
    public abstract class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
