﻿using EF3Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF3Data.Data
{
    public class DataCreator
    {
        public DataCreator(string userName)
        {
            Container = new DataContainer();
            int seed = 0;
            foreach (char c in userName)
            {
                seed += c;
            }

            random = new Random(seed);
        }

        public DataContainer Container { get; private set; }
        private Random random { get; set; }

        public DataContainer GetData()
        {
            CreateUsers();
            CreatePostTypes();
            CreateBlogTypes();
            CreateBlogs();
            CreatePosts();
            return Container;
        }

        private void CreateUsers()
        {
            var userCount = random.Next(50, 500);

            for (int i = 0; i < userCount; i++)
            {
                var user = new User();
                var firstname = Constants.FirstName[random.Next(Constants.FirstName.Count)];
                var lastname = Constants.LastName[random.Next(Constants.LastName.Count)];
                user.Name = $"{firstname} {lastname}";
                user.EmailAddress = Constants.DummyEmails[random.Next(Constants.DummyEmails.Count)];
                user.PhoneNumber = "1234567890";
                Container.Users.Add(user);
            }
        }

        private void CreatePostTypes()
        {
            var postTypeCount = random.Next(10, 100);
            for (int i = 0; i < postTypeCount; i++)
            {
                var postType = new PostType();
                postType.Status = random.Next(11) % 2 == 0 ? Statuses.Active : Statuses.Inactive;
                postType.Name = Constants.PostTypes[random.Next(Constants.PostTypes.Count)];
                postType.Description = postType.Name;
                Container.PostTypes.Add(postType);
            }
        }

        private void CreateBlogTypes()
        {
            var blogTypeCount = random.Next(10, 100);
            for (int i = 0; i < blogTypeCount; i++)
            {
                var blogtype = new BlogType();
                blogtype.Status = random.Next(11) % 2 == 0 ? Statuses.Active : Statuses.Inactive;
                blogtype.Name = Constants.BlogTypes[random.Next(Constants.BlogTypes.Count)];
                blogtype.Description = blogtype.Name;
                Container.BlogTypes.Add(blogtype);
            }
        }

        private void CreateBlogs()
        {
            var blogCount = random.Next(30, 150);
            for (int i = 0; i < blogCount; i++)
            {
                var blog = new Blog();
                blog.IsPublic = random.Next(11) % 2 == 0;
                blog.Url = Constants.DummyUrls[random.Next(Constants.DummyUrls.Count)];

                Container.BlogTypes[random.Next(Container.BlogTypes.Count)].Blogs.Add(blog);

                Container.Blogs.Add(blog);
            }
        }

        private void CreatePosts()
        {
            var postCount = random.Next(300, 800);
            for (int i = 0; i < postCount; i++)
            {
                var post = new Post();
                post.Title = $"Test Post {i}";
                post.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

                Container.PostTypes[random.Next(Container.PostTypes.Count)].Posts.Add(post);
                Container.Blogs[random.Next(Container.Blogs.Count)].Posts.Add(post);
                Container.Users[random.Next(Container.Users.Count)].Posts.Add(post);

                Container.Posts.Add(post);
            }
        }
    }
}
