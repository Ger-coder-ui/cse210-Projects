using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Represents a comment on a YouTube video
    public class Comment
    {
        public string Author { get; }
        public string Text { get; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }
    }

    // Represents a YouTube video
    public class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int LengthInSeconds { get; }
        private List<Comment> Comments { get; } = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        // Adds a comment to the video
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        // Returns the number of comments
        public int GetCommentCount()
        {
            return Comments.Count;
        }

        // Displays the video details and its comments
        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds / 60} minutes");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            // Create videos
            var video1 = new Video("Learning C# Basics", "Jane Doe", 300);
            var video2 = new Video("Advanced C# Techniques", "John Smith", 450);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great introduction to C#!"));
            video1.AddComment(new Comment("Bob", "Very clear explanations."));
            video1.AddComment(new Comment("Charlie", "Looking forward to more tutorials."));

            // Add comments to video2
            video2.AddComment(new Comment("David", "This helped me understand delegates better."));
            video2.AddComment(new Comment("Eve", "The examples were very practical."));
            video2.AddComment(new Comment("Frank", "Please cover LINQ in the next video."));
            video2.AddComment(new Comment("Grace", "I appreciate the depth of coverage."));

            // Create a list of videos
            var videos = new List<Video> { video1, video2 };

            // Display details of each video
            foreach (var video in videos)
            {
                video.DisplayVideoDetails();
            }
        }
    }
}
