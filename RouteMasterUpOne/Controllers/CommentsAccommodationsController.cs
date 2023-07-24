using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RouteMasterUpOne.Models;
using RouteMasterUpOne.Models.Dtos;
using RouteMasterUpOne.Models.EFRepositories;
using RouteMasterUpOne.Models.Exts;
using RouteMasterUpOne.Models.Interfaces;
using RouteMasterUpOne.Models.Services;
using RouteMasterUpOne.Models.ViewModels;

namespace RouteMasterUpOne.Controllers
{
    public class CommentsAccommodationsController : Controller
    {
        private readonly CoreRouteMasterContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;


        public CommentsAccommodationsController(CoreRouteMasterContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CommentsAccommodations
        public async Task<IActionResult> Index()
        {
            ICommentsAccommodationsRepository repo = new CommentsAccommodationsEFRepository();
            CommentsAccommodationsService service = new CommentsAccommodationsService(repo);

            var dto = await service.Search();
            var vm =dto.Select(c => c.ToIndexVM());

			return View(vm);
        }

        // GET: CommentsAccommodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CommentsAccommodations == null)
            {
                return NotFound();
            }

            var commentsAccommodation = await _context.CommentsAccommodations
                .Include(c => c.Accommodation)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentsAccommodation == null)
            {
                return NotFound();
            }

            return View(commentsAccommodation);
        }

        // GET: CommentsAccommodations/Create
        public IActionResult Create()
        {
			//傳入參數:AccomodationId
			//CommentsAccommodationsCreateVM vm = new CommentsAccommodationsCreateVM();
			//vm.AccommodationId = "傳入參數";
			//vm.MemberId = User.Identity.Account;


			ViewBag.AccommodationId = new SelectList(_context.Accommodations, "Id", "Name");
			ViewBag.MemberId = new SelectList(_context.Members, "Id", "Account");
            return View();
        }

        // POST: CommentsAccommodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentsAccommodationsCreateVM vm, List<IFormFile> file1)
        {
            ViewBag.AccommodationId = new SelectList(_context.Accommodations, "Id", "Name", vm.AccommodationId);
            ViewBag.MemberId = new SelectList(_context.Members, "Id", "Account", vm.MemberId);
           
            if (ModelState.IsValid)
            {
                CommentsAccommodation commentDb = new CommentsAccommodation
                {
                    AccommodationId = vm.AccommodationId,
                    MemberId = vm.MemberId,
                    Score = vm.Score,
                    Title = vm.Title,
                    Pros = vm.Pros,
                    Cons = vm.Cons,
                    CreateDate = DateTime.Now

                };
                _context.CommentsAccommodations.Add(commentDb);
                await _context.SaveChangesAsync();


                string webRootPath = _webHostEnvironment.WebRootPath;
                string path = Path.Combine(webRootPath, "Uploads");

                foreach (IFormFile i in file1)
                {
                    if (i != null && i.Length>0)
                    {

                        CommentsAccommodationImage img = new CommentsAccommodationImage();
                        string fileName = SaveUploadedFile(path, i);
                        img.CommentsAccommodationId = commentDb.Id;
                        img.Image = fileName;
                        _context.CommentsAccommodationImages.Add(img);
                        await _context.SaveChangesAsync();
                    }
                    //else
                    //{
                    //    await _context.SaveChangesAsync();
                    //}

                   
                }
                return RedirectToAction(nameof(Index));


            }
           
            return View(vm);
        }

        private string SaveUploadedFile(string path, IFormFile file1)
        {
            // 如果沒有上傳檔案或檔案是空的,就不處理, 傳回 string.empty
            if (file1 == null ) return string.Empty;

            // 取得上傳檔案的副檔名
            string ext = System.IO.Path.GetExtension(file1.FileName); // ".jpg" 而不是 "jpg"

            // 如果副檔名不在允許的範圍裡,表示上傳不合理的檔案類型, 就不處理, 傳回 string.empty
            string[] allowedExts = new string[] { ".jpg", ".jpeg", ".png", ".tif" };
            if (allowedExts.Contains(ext.ToLower()) == false) return string.Empty;

            // 生成一個不會重複的檔名
            string newFileName = Guid.NewGuid().ToString("N") + ext; // 生成 亂碼.jpg
            string fullName = System.IO.Path.Combine(path, newFileName);

            // 將上傳檔案存放到指定位置
            using (var stream = new FileStream(fullName, FileMode.Create))
            {
                file1.CopyTo(stream);
            }

            // 傳回存放的檔名
            return newFileName;
        }

        // GET: CommentsAccommodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CommentsAccommodations == null)
            {
                return NotFound();
            }

            var commentDb = await _context.CommentsAccommodations.FindAsync(id);
            if (commentDb == null)
            {
                return NotFound();
            }
            CommentsAccommodationsEditVM vm = new CommentsAccommodationsEditVM
            {
                Id = (int)id,
                Title = commentDb.Title,
                Score = commentDb.Score,
                Pros = commentDb.Pros,
                Cons = commentDb.Cons
            };

            //ViewData["AccommodationId"] = new SelectList(_context.Accommodations, "Id", "Name", commentDb.AccommodationId);
            //ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Account", commentDb.MemberId);
            return View(vm);
        }

        // POST: CommentsAccommodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CommentsAccommodationsEditVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var commentDb = await _context.CommentsAccommodations.FindAsync(id);
                commentDb.Score = vm.Score;
                commentDb.Title = vm.Title;
                commentDb.Pros = vm.Pros;
                commentDb.Cons = vm.Cons;
                try
                {
                    _context.Update(commentDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsAccommodationExists(commentDb.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AccommodationId"] = new SelectList(_context.Accommodations, "Id", "Id", commentsAccommodation.AccommodationId);
            //ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", commentsAccommodation.MemberId);
            return View(vm);
        }

        // GET: CommentsAccommodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentDb = await _context.CommentsAccommodations
                .Include(c => c.Accommodation)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (commentDb == null)
            {   
                return NotFound();
            }

            return View(commentDb);
        }

        // POST: CommentsAccommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CommentsAccommodations == null)
            {
                return Problem("Entity set 'CoreRouteMasterContext.CommentsAccommodations'  is null.");
            }
            var commentDb = await _context.CommentsAccommodations.FindAsync(id);
            if (commentDb != null)
            {
                _context.CommentsAccommodations.Remove(commentDb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsAccommodationExists(int id)
        {
          return (_context.CommentsAccommodations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
