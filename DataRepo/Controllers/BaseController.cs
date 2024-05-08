using DataRepo.Interfaces;
using DataRepo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataRepo.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IPostsService _postsService;

    protected BaseController(IPostsService postsService)
    {
        _postsService = postsService ?? throw new ArgumentNullException();
    }
}
