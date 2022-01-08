namespace Test9.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Category_Id { get; set; }
        public int Author_Id { get; set; }
        public int Color_Id { get; set; }

        public virtual Color Color { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }


        //public enum Category { Comedy, Adventure, Romance, Horror, Thriller }
        //public enum Color { Red, Green, Blue }
        //public enum Material { Digital, Physical }
    }
}
