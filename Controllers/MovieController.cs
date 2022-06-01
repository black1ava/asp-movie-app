using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers {
  public class MovieController: Controller {
    private readonly MovieAppDbContext context;
    public MovieController(MovieAppDbContext context){
      this.context = context;
    } 
    public async Task<IActionResult> Index(){
      var movies = await this.context.Movies.ToListAsync();
      return View(movies);
    }
    public IActionResult Create(){
      ViewBag.subtitles = Enum.GetValues(typeof(Subtitles)).Cast<Subtitles>().Select(subtitle => new SelectListItem {
        Text = subtitle.ToString(),
        Value = subtitle.ToString()
      }).ToList();

      ViewBag.movieTypes = Enum.GetValues(typeof(MovieTypes)).Cast<MovieTypes>().Select(movieType => new SelectListItem {
        Text = movieType.ToString(),
        Value = movieType.ToString()
      }).ToList();

      ViewBag.languages = Enum.GetValues(typeof(Languages)).Cast<Languages>().Select(language => new SelectListItem {
        Text = language.ToString(),
        Value = language.ToString()
      }).ToList();

      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Movie movie){
      await this.context.Movies.AddAsync(movie);
      await this.context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int id){
      var movie = await this.context.Movies.FindAsync(id);
      return View(movie);
    }
    public async Task<IActionResult> Edit(int id){
      var movie = await this.context.Movies.FindAsync(id);

      ViewBag.subtitles = Enum.GetValues(typeof(Subtitles)).Cast<Subtitles>().Select(subtitle => new SelectListItem {
        Text = subtitle.ToString(),
        Value = subtitle.ToString()
      }).ToList();

      ViewBag.movieTypes = Enum.GetValues(typeof(MovieTypes)).Cast<MovieTypes>().Select(movieType => new SelectListItem {
        Text = movieType.ToString(),
        Value = movieType.ToString()
      }).ToList();

      ViewBag.languages = Enum.GetValues(typeof(Languages)).Cast<Languages>().Select(language => new SelectListItem {
        Text = language.ToString(),
        Value = language.ToString()
      }).ToList();

      return View(movie);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Movie movie){
      this.context.Movies.Update(movie);
      await this.context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id){
      var movie = await this.context.Movies.FindAsync(id);
      if(movie != null){
        this.context.Movies.Remove(movie);
        await this.context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }
  }
}