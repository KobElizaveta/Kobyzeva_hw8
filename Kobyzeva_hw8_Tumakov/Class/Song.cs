namespace Kobyzeva_hw8_Tumakov.Class
{
    internal class Song
    {
        public string Name;
        public string Author;
        public Song Prev;

        public Song()
        {
            Name = "Неизвестное имя";
            Author = "Неизвестный исполнитель";
            Prev = null;
        }

        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название - {Name}, исполнитель - {Author}");
        }

        public string Title()
        {
            return Name + "+" + Author;
        }

        public override bool Equals(object d)
        {
            try
            {
                Song PrevSong = (Song)d;
                if (PrevSong.Name == Name && PrevSong.Author == Author)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
