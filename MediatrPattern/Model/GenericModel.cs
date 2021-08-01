using System;

namespace MediatrPattern.Model
{
    public class GenericModel
    {
        public long Id { get; set; }
        public char RecStatus { get; set; } = 'A';
        public DateTime RecDate { get; set; } = DateTime.Now;
    }
}