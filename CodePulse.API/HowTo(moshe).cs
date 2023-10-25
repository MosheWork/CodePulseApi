//**add blogpost api***
//1.add new controller BlogPostsController.cs  (api >api empety controller )
//2.add new DTO CreateBlogPostRequestDto.cs and make allmost the same as model blogpost ( no id )
//3.blogPostsControl set up request  [HttpPost]
//4.interface add new interface IBlogPostRepository and add task
//5. add new class in implementation BlogPostRepository.cs  and implment new interface
//6. program.cs inject the new service builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
//7.go back to blogPostController inject the repostry inside a constractor 
//   private readonly IBlogPostRepository blogPostRepository;
//public BlogPostsController(IBlogPostRepository blogPostRepository)
//{
//    this.blogPostRepository = blogPostRepository;
//}

//inside CreateBlogPost we add  blogPost=  await blogPostRepository.CreateAsync(blogPost);

//8. add new DTO BlogPostDto.cs  copy same propaty ad the BlogPost model/domain
//9. in BlogPost Controller we map the dto 

//var response = new BlogPostDto
//{
//    Id = blogPost.Id,
//    Author = blogPost.Author,
//    Content = blogPost.Content,
//    FeaturedImageUrl = blogPost.FeaturedImageUrl,
//    IsVisible = blogPost.IsVisible,
//    PublishedData = blogPost.PublishedData,
//    ShortDescription = blogPost.ShortDescription,
//    Title = blogPost.Title,
//    UrlHandle = blogPost.UrlHandle,
//};
//return Ok(response);

//10.test in swagger


//***** get all post ****
//1.in blogpost controll new public async Task<IActionResult> getAllBlogPost() { }
//2. intrface - Task<IEnumerable<BlogPost>> GetAllAsync();
//3.implementation - blogPostReposoitory -press on IBlogPostRepository and implent new interface = public Task<IEnumerable<BlogPost>> GetAllAsync(){}
//   public async Task<IEnumerable<BlogPost>> GetAllAsync()
//using Microsoft.EntityFrameworkCore;
//{
//    return await dbContext.BlogPosts.ToListAsync();
//}

//4.

