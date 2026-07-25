using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Unboxing the New Trail Backpack", "OutdoorGearReviews", 612);
        video1.AddComment(new Comment("Amina", "This is exactly the backpack I needed, thanks!"));
        video1.AddComment(new Comment("Kevin", "Does it fit a 15 inch laptop?"));
        video1.AddComment(new Comment("Priya", "Great review as always."));

        Video video2 = new Video("Cooking Ugali the Right Way", "MamaMwiku Kitchen", 480);
        video2.AddComment(new Comment("Brian", "This brought back so many memories."));
        video2.AddComment(new Comment("Faith", "Finally got the consistency right, thank you!"));
        video2.AddComment(new Comment("Tom", "Can you do a video on sukuma wiki next?"));
        video2.AddComment(new Comment("Grace", "Watching this before dinner was a mistake, I'm starving now."));

        Video video3 = new Video("Learn C# in 20 Minutes", "CodeWithDavid", 1230);
        video3.AddComment(new Comment("Samuel", "This helped me understand classes way better than my textbook."));
        video3.AddComment(new Comment("Linda", "Could you cover interfaces next?"));
        video3.AddComment(new Comment("Josh", "Subscribed after this one."));

        Video video4 = new Video("Nairobi Street Food Tour", "UrbanEatsKE", 905);
        video4.AddComment(new Comment("Wanjiru", "Now I'm craving mutura."));
        video4.AddComment(new Comment("Peter", "Which stall was your favorite?"));
        video4.AddComment(new Comment("Nia", "This city has the best street food, hands down."));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
