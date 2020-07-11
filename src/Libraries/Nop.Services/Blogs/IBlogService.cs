﻿using System;
using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Blogs;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// Represents a blog service
    /// </summary>
    public partial interface IBlogService
    {
        #region Blog posts

        /// <summary>
        /// Insert the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        void InsertBlogPost(BlogPost blogPost);

        /// <summary>
        /// Update the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        void UpdateBlogPost(BlogPost blogPost);

        /// <summary>
        /// Delete the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        void DeleteBlogPost(BlogPost blogPost);

        /// <summary>
        /// Gets a blog post
        /// </summary>
        /// <param name="id">Blog post identifier</param>
        /// <returns>Blog post</returns>
        BlogPost GetBlogPostById(int id);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
        /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="title">Filter by blog post title</param>
        /// <returns>Blog posts</returns>
        IPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false, string title = null);

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="tag">Tag</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog posts</returns>
        IPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// Gets all blog post tags
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog post tags</returns>
        IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false);

        /// <summary>
        /// Returns all posts published between the two dates.
        /// </summary>
        /// <param name="blogPosts">Source</param>
        /// <param name="dateFrom">Date from</param>
        /// <param name="dateTo">Date to</param>
        /// <returns>Filtered posts</returns>
        IList<BlogPost> GetPostsByDate(IList<BlogPost> blogPosts, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Parse tags
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <returns>Tags</returns>
        IList<string> ParseTags(BlogPost blogPost);

        /// <summary>
        /// Get a value indicating whether a blog post is available now (availability dates)
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="dateTime">Datetime to check; pass null to use current date</param>
        /// <returns>Result</returns>
        bool BlogPostIsAvailable(BlogPost blogPost, DateTime? dateTime = null);

        #endregion

        #region Blog comments

        /// <summary>
        /// Insert the blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        void InsertBlogComment(BlogComment blogComment);

        /// <summary>
        /// Update the blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        void UpdateBlogComment(BlogComment blogComment);

        /// <summary>
        /// Delete the blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        void DeleteBlogComment(BlogComment blogComment);

        /// <summary>
        /// Delete blog comments
        /// </summary>
        /// <param name="blogComments">Blog comments</param>
        void DeleteBlogComments(IEnumerable<BlogComment> blogComments);

        /// <summary>
        /// Gets a blog comment
        /// </summary>
        /// <param name="id">Blog comment identifier</param>
        /// <returns>Blog comment</returns>
        BlogComment GetBlogCommentById(int id);

        /// <summary>
        /// Gets blog comments
        /// </summary>
        /// <param name="ids">Blog comment identifiers</param>
        /// <returns>Blog comment</returns>
        IList<BlogComment> GetBlogCommentsByIds(IEnumerable<int> ids);

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="blogPostId">Blog post ID; 0 or null to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item creation to; null to load all records</param>
        /// <param name="commentText">Search comment text; null to load all records</param>
        /// <returns>Comments</returns>
        IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null);

        /// <summary>
        /// Get the count of blog comments
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of blog comments</returns>
        int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null);

        #endregion
    }
}