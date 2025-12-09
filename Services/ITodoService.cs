using GitDemoToDoApp.Models;

namespace GitDemoToDoApp.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetAllTodos();
        TodoItem GetTodoById(int id);
        void CreateTodo(TodoItem todo);
        void UpdateTodo(TodoItem todo);
        void DeleteTodo(int id);
    }
}
