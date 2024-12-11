using AutoMapper;
using Mohtawa.Domain.Contracts;
using Mohtawa.Domain.DTOs;
using Mohtawa.Domain.IRepositories;
using Mohtawa.Domain.Models;
using Mohtawa.Domain.Requests;
using Mohtawa.Domain.Responses;

namespace Mohtawa.Application.Services
{
    public class BookService : IBookService
    {

        #region Properties
        private readonly ILibraryUnitOfWork _libraryUnitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Methods
        public BookService(IMapper mapper, ILibraryUnitOfWork libraryUnitOfWork)
        {
            _mapper = mapper;
            _libraryUnitOfWork = libraryUnitOfWork;
        }

        public async Task<GetBooksResponse> GetListAsync()
        {
            try
            {
                var books = await _libraryUnitOfWork.BookRepository.GetAllAsync();

                return new GetBooksResponse
                {
                    Data = _mapper.Map<List<BookDTO>>(books),
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<GetBookResponse> GetAsync(int id)
        {
            var book = await _libraryUnitOfWork.BookRepository.GetByIdAsync(id);

            return new GetBookResponse
            {
                Data = _mapper.Map<BookDTO>(book),
            };

        }
        public async Task<AddBookResponse> AddAsync(AddBookRequest request)
        {
            try
            {
                // add some conditions for validate request or add any validateions
                if (request is null)
                {
                    throw new Exception("Invalid Request");
                }

                var book = _mapper.Map<Book>(request);

                await _libraryUnitOfWork.BookRepository.AddAsync(book);

                await _libraryUnitOfWork.SaveAsync();

                return new AddBookResponse
                {
                    MessageDTOs = new List<MessageDTO>
                    {
                       new MessageDTO
                       {
                         Message = "Add book is done successfully",
                         Type = Domain.Enums.MessageTypeEnum.Information
                       }
                    }
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<AddBookResponse> UpdateAsync(int id, UpdateBookRequest request)
        {
            try
            {
                // add some conditions for validate request or add any validateions
                if (request is null)
                {
                    throw new Exception("Invalid Request");
                }

                var book = _mapper.Map<Book>(request);

                book.Id = id;
                _libraryUnitOfWork.BookRepository.Update(book);
                await _libraryUnitOfWork.SaveAsync();

                return new AddBookResponse
                {
                    MessageDTOs = new List<MessageDTO>
                    {
                       new MessageDTO
                       {
                         Message = "Update book is done successfully",
                         Type = Domain.Enums.MessageTypeEnum.Information
                       }
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<DeleteBookResponse> DeleteAsync(int id, DeleteBookRequest request)
        {
            try
            {
                var book = await _libraryUnitOfWork.BookRepository.GetByIdAsync(request.Id);
                if (book is null)
                {
                    throw new Exception("this book is not found");
                }

                _libraryUnitOfWork.BookRepository.Delete(book);

                await _libraryUnitOfWork.SaveAsync();

                return new DeleteBookResponse
                {
                    MessageDTOs = new List<MessageDTO>
                    {
                       new MessageDTO
                       {
                         Message = "Delete book is done successfully",
                         Type = Domain.Enums.MessageTypeEnum.Information
                       }
                    }
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}