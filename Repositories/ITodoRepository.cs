using GitDemoToDoApp.Models;

namespace GitDemoToDoApp.Repositories
{
    public interface ITodoRepository
    {
        List<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
    }
}
