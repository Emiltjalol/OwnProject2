namespace OwnProject2.Models
{
    public class Dog
    {

        public Guid Id { get; set; }
        public string image_link { get; set; }
        public int good_with_children { get; set; }
        public int good_with_other_dogs { get; set; }
        public int shedding { get; set; }
        public int grooming { get; set; }
        public int drooling { get; set; }
        public int coat_length { get; set; }
        public int good_with_strangers { get; set; }
        public int playfulness { get; set; }
        public int protectiveness { get; set; }
        public int trainability { get; set; }
        public int energy { get; set; }
        public int barking { get; set; }
        public double min_life_expectancy { get; set; }
        public double max_life_expectancy { get; set; }
        public double max_height_male { get; set; }
        public double max_height_female { get; set; }
        public double max_weight_male { get; set; }
        public double max_weight_female { get; set; }
        public double min_height_male { get; set; }
        public double min_height_female { get; set; }
        public double min_weight_male { get; set; }
        public double min_weight_female { get; set; }
        public string name { get; set; }
    }
 
   
}

