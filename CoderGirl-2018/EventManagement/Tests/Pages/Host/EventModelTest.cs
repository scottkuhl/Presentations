using EventManagement.Data;
using EventManagement.Models;
using EventManagement.Pages.Host;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Pages.Host
{
    public class EventModelTest
    {
        AppDbContext _context;
        EventModel _pageModel;
        UserManager<AppUser> _userManager;

        public EventModelTest()
        {
            _context = Helpers.CreateContext();
            _userManager = Helpers.MockUserManager(new AppUser { Id = 1, UserName = "Test" }).Object;
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;
            _pageModel.TryValidateModelResult = true;
        }

        [Fact]
        public async Task OnGetAsync_ReturnsANotFoundObjectResult_WhenUserIsNotFound()
        {
            // Arrange
            _userManager = Helpers.MockUserManager((AppUser)null).Object;
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnGetAsync(null);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ReturnsANotFoundResult_WhenEventIsNotFound()
        {
            // Arrange
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnGetAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ReturnsAForbidResult_WhenUserIsNotEventHost()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 2 });
            _context.Events.Add(new Event { Id = 1, HostId = 2 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnGetAsync(1);

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ReturnsAPageResult_WhenNewEvent()
        {
            // Arrange
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnGetAsync(null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ReturnsAPageResult_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnGetAsync(1);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_MapsId_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal(1, _pageModel.Event.Id);
        }

        [Fact]
        public async Task OnGetAsync_MapsTitle_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, Title = "Test" });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal("Test", _pageModel.Event.Title);
        }

        [Fact]
        public async Task OnGetAsync_MapsDescription_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, Description = "Test" });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal("Test", _pageModel.Event.Description);
        }

        [Fact]
        public async Task OnGetAsync_MapsStart_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, Start = DateTime.Parse("1/1/2019") });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal(DateTime.Parse("1/1/2019"), _pageModel.Event.Start);
        }

        [Fact]
        public async Task OnGetAsync_MapsEnd_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, End = DateTime.Parse("1/1/2019") });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal(DateTime.Parse("1/1/2019"), _pageModel.Event.End);
        }

        [Fact]
        public async Task OnGetAsync_MapsLocation_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, Location = "Test" });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal("Test", _pageModel.Event.Location);
        }

        [Fact]
        public async Task OnGetAsync_MapsMaxCapacity_WhenEventIsFound()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1, MaxCapacity = 1 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            await _pageModel.OnGetAsync(1);

            // Assert
            Assert.Equal((short)1, _pageModel.Event.MaxCapacity);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsANotFoundObjectResult_WhenUserIsNotFound()
        {
            // Arrange
            _userManager = Helpers.MockUserManager((AppUser)null).Object;
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsANotFoundResult_WhenEventIsNotFound()
        {
            // Arrange
            _pageModel.Event = new EventViewModel { Id = 1 };

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsAForbidResult_WhenUserIsNotEventHost()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 2 });
            _context.Events.Add(new Event { Id = 1, HostId = 2 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;
            _pageModel.Event = new EventViewModel { Id = 1 };

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelStateIsInvalid()
        {
            // Arrange
            _pageModel.ModelState.AddModelError(string.Empty, "Test");

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelIsInvalid()
        {
            // Arrange
            _pageModel.TryValidateModelResult = false;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_CreatesRecord_WhenPostIsValid()
        {
            // Arrange
            _pageModel.Event = ValidEventViewModel();

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.True((await _context.Events.FirstAsync()).Id > 0);
        }

        [Fact]
        public async Task OnPostAsync_SavesHostId_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(1, (await _context.Events.FirstAsync()).HostId);
        }

        [Fact]
        public async Task OnPostAsync_SavesTitle_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.Title, (await _context.Events.FirstAsync()).Title);
        }

        [Fact]
        public async Task OnPostAsync_SavesDescription_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.Description, (await _context.Events.FirstAsync()).Description);
        }

        [Fact]
        public async Task OnPostAsync_SavesStart_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.Start, (await _context.Events.FirstAsync()).Start);
        }

        [Fact]
        public async Task OnPostAsync_SavesEnd_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.End, (await _context.Events.FirstAsync()).End);
        }

        [Fact]
        public async Task OnPostAsync_SavesLocation_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.Location, (await _context.Events.FirstAsync()).Location);
        }

        [Fact]
        public async Task OnPostAsync_SavesMaxCapacity_WhenCreatingARecord()
        {
            // Arrange
            var vm = ValidEventViewModel();
            _pageModel.Event = vm;

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.Equal(vm.MaxCapacity, (await _context.Events.FirstAsync()).MaxCapacity);
        }

        [Fact]
        public async Task OnPostAsync_ReturnsRedirect_WhenPostIsValid()
        {
            // Arrange
            _pageModel.Event = new EventViewModel
            {
                Title = "Test",
                Description = Helpers.FillString(100),
                Start = DateTime.Now,
                End = DateTime.Now.AddSeconds(1),
                Location = "Test"
            };

            // Act
            var result = await _pageModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteAsync_ReturnsANotFoundObjectResult_WhenUserIsNotFound()
        {
            // Arrange
            _userManager = Helpers.MockUserManager((AppUser)null).Object;
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnPostDeleteAsync(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteAsync_ReturnsANotFound_WhenTheEventDoesNotExist()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _pageModel.OnPostDeleteAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteAsync_ReturnsAForbidResult_WhenUserIsNotEventHost()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 2 });
            _context.Events.Add(new Event { Id = 1, HostId = 2 });
            await _context.SaveChangesAsync();
            _pageModel = Helpers.CreatePageModel(new EventModel(_context, _userManager)) as EventModel;

            // Act
            var result = await _pageModel.OnPostDeleteAsync(1);

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageResult_WhenTheEventIsDeleted()
        {
            // Arrange
            _context.AppUsers.Add(new AppUser { Id = 1 });
            _context.Events.Add(new Event { Id = 1, HostId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _pageModel.OnPostDeleteAsync(1);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public void EventViewModel_Title_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new EventViewModel();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Title is required.");
        }

        [Fact]
        public void EventViewModel_Title_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new EventViewModel { Title = Helpers.FillString(201) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Title can not be longer than 200 characters.");
        }

        [Fact]
        public void EventViewModel_Description_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new EventViewModel();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Description is required.");
        }

        [Fact]
        public void EventViewModel_Description_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new EventViewModel { Description = Helpers.FillString(2001) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Description must be between 100 and 2000 characters.");
        }

        [Fact]
        public void EventViewModel_Description_ReturnsInvalid_WhenNotLongEnough()
        {
            // Arrange
            var evt = new EventViewModel { Description = Helpers.FillString(99) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Description must be between 100 and 2000 characters.");
        }

        [Fact]
        public void EventViewModel_Location_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new EventViewModel();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Location is required.");
        }

        [Fact]
        public void EventViewModel_Location_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new EventViewModel { Location = Helpers.FillString(201) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "Location can not be longer than 200 characters.");
        }

        private EventViewModel ValidEventViewModel()
        {
            return new EventViewModel
            {
                Title = "Test",
                Description = Helpers.FillString(100),
                Start = DateTime.Now,
                End = DateTime.Now.AddSeconds(1),
                Location = "Test",
                MaxCapacity = 10
            };
        }
    }
}