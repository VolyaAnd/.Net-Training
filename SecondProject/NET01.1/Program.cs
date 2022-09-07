
namespace NET01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextMaterial text1 = new TextMaterial("Lorem ipsum");
            VideoMaterial video1 = new VideoMaterial("youtube.com", "image.com", Videoformat.Mp4);
            Link link1 = new Link("training-center.by", LinkType.Unknown); 
            Lesson lesson1 = new Lesson( Materials);
            lesson1.Materials.Add(text1);
            lesson1.Materials.Add(video1);
            lesson1.Materials.Add(link1);

            
            //Guid guid = video1.GenerateId();
            //text1.Id = guid;  
            bool isEqual = text1.Equals(video1);
            //System.Console.WriteLine(isEqual);
            

        }
    }
}
