using Ispit.API.Models;

namespace Ispit.API.Services
{
    public interface ITodoService
    {
        TodoList CreateTodoList(TodoList model);
        void DeleteTodoList(int id);
        TodoList GetTodoList(int id);
        List<TodoList> GetTodoLists();
        TodoList UpdateTodoList(TodoList model);
    }
}