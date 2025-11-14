namespace cuccos
{
    public class Blogger
    {
        private int id;
        private string name;
        private string email;
        private DateTime regtime;
        private DateTime modtime;

        public Blogger(int id, string name, string email, DateTime regtime, DateTime modtime)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Regtime = regtime;
            this.Modtime = modtime;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Regtime { get => regtime; set => regtime = value; }
        public DateTime Modtime { get => modtime; set => modtime = value; }
    }
}
