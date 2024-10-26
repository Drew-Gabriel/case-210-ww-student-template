using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    // Class to represent a Comment
    public class Comment
    {
        public string CommenterName { get; private set; }
        public string Text { get; private set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Class to represent a Video
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int LengthInSeconds { get; private set; }
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        // Method to add a comment
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Method to get the number of comments
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        // Method to get all comments
        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Create some videos and add comments to them
            Video video1 = new Video("Understanding Abstraction in C#", "John Doe", 300);
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Thanks for this tutorial."));
            video1.AddComment(new Comment("Charlie", "I learned a lot!"));

            Video video2 = new Video("Polymorphism in Programming", "Jane Smith", 450);
            video2.AddComment(new Comment("Dave", "Very helpful, thank you!"));
            video2.AddComment(new Comment("Eve", "Nice examples."));
            video2.AddComment(new Comment("Frank", "Can't wait to try this out."));

            Video video3 = new Video("C# Classes and Objects", "Emily Johnson", 600);
            video3.AddComment(new Comment("Grace", "This is exactly what I needed!"));
            video3.AddComment(new Comment("Heidi", "Well explained."));
            video3.AddComment(new Comment("Ivan", "Fantastic content!"));

   st
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                
                Console.WriteLine(); // Blank line for separation
            }
        }
    }
}
