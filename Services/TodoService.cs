using Ispit.API.Data;
using Ispit.API.Models;

namespace Ispit.API.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext db;

        public TodoService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<TodoList> GetTodoLists()
        {
            return db.TodoList.ToList();
        }

        public TodoList GetTodoList(int id)
        {
            var todo = db.TodoList.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return null;
            }
            return todo;
        }

        public TodoList CreateTodoList(TodoList model)
        {
            var newList = new TodoList()
            {                
                Title = model.Title,
                Description = model.Description,
                IsCompleted = model.IsCompleted
            };

            db.Add(newList);
            db.SaveChanges();
            return newList;
        }
        public TodoList? UpdateTodoList(TodoList model)
        {

            var todo = db.TodoList.FirstOrDefault(x => x.Id == model.Id);
            if (todo == null) { return null; }
            
            todo.Title = model.Title;
            todo.Description = model.Description;
            todo.IsCompleted = model.IsCompleted;


            db.SaveChanges();
            return todo;
        }
        public void DeleteTodoList(int id)
        {
            var todo = db.TodoList.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                db.Remove(todo);
            }
            db.SaveChanges();
        }
    }
}
