using AutoMapper;
using toDoList.Dtos;
using toDoList.Model;

public class Automapper: Profile
{
    public Automapper()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        CreateMap<CreateCategoryDto,CategoryDto>().ReverseMap();
        CreateMap<CreateToDoItemDto, ToDoItem>().ReverseMap();
        CreateMap<UpdateToDoItemDto, ToDoItem>().ReverseMap();
        CreateMap<ToDoItemDto, ToDoItem>().ReverseMap();
        
    }
}
