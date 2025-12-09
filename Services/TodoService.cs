using GitDemoToDoApp.Models;
using GitDemoToDoApp.Repositories;

namespace GitDemoToDoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<TodoItem> GetAllTodos()
        {
            return _todoRepository.GetAll();
        }

        public TodoItem GetTodoById(int id)
        {
            return _todoRepository.GetById(id);
        }

        public void CreateTodo(TodoItem todo)
        {
            // Ici, tu pourrais ajouter de la logique métier avant de créer
            _todoRepository.Add(todo);
        }

        public void UpdateTodo(TodoItem todo)
        {
            // Ici aussi, tu pourrais ajouter de la logique métier
            _todoRepository.Update(todo);
        }

        public void DeleteTodo(int id)
        {
            _todoRepository.Delete(id);
        }
    }
}
