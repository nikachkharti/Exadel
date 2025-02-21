﻿using AutoMapper;
using BookManagement.Models.Dtos;
using BookManagement.Models.Entities;
using BookManagement.Repository.Contracts;
using BookManagement.Service.Contracts;
using BookManagement.Service.Exceptions;
using BookManagement.Service.Exceptions.Base.Exceptions;
using BookManagement.Service.Mapping;

namespace BookManagement.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = MappingInitializer.Initialize();
        }

        public Task<IEnumerable<Guid>> AddMultipleBooks(HashSet<BookForCreatingDto> booksForCreatingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AddSingleBook(BookForCreatingDto bookForCreatingDto)
        {
            if (bookForCreatingDto is null)
            {
                throw new BadRequestException("Invalid argument passed", $"{nameof(bookForCreatingDto)} is an invalid argument");
            }

            if (await BookAlreadyExists(bookForCreatingDto.Title))
            {
                throw new BookAlreadyExistsException(bookForCreatingDto.Title);
            }

            var bookEntity = _mapper.Map<Book>(bookForCreatingDto);
            await _bookRepository.AddAsync(bookEntity);

            return bookEntity.Id;
        }

        public Task<IEnumerable<Guid>> DeleteMultipleBooks(HashSet<Guid> bookIds)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> DeleteSingleBook(Guid bookId)
        {
            var entityToDelete = await _bookRepository.GetAsync(x => x.Id == bookId);

            if (entityToDelete is null)
            {
                throw new BookNotFoundException(bookId.ToString());
            }

            _bookRepository.Remove(entityToDelete);
            return bookId;
        }

        public async Task<BookForGettingDto> GetBookDetails(Guid bookId)
        {
            var bookEntity = await _bookRepository.GetAsync(x => x.Id == bookId);

            if (bookEntity is null)
            {
                throw new BookNotFoundException(bookId.ToString());
            }

            //TODO update book views before return.
            return _mapper.Map<BookForGettingDto>(bookEntity);
        }

        public async Task<List<string>> GetPopularBooks(int pageNumber = 1, int pageSize = 10)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            if (pageSize < 1 || pageSize > 50) pageSize = 10;

            var rawData = await _bookRepository.GetAllAsync(pageNumber, pageSize);
            List<string> result = new();

            if (rawData.Any())
            {
                result = rawData
                    .OrderByDescending(x => x.ViewCount)
                    .Select(x => x.Title)
                    .ToList();
            }

            return result;
        }

        public Task<Guid> UpdateSingleBook(BookForUpdatingDto bookForUpdatingDto)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> BookAlreadyExists(string bookName)
        {
            var result = await _bookRepository.GetAsync(x => x.Title.ToLower().Trim() == bookName.ToLower().Trim());
            return result is not null;
        }
    }
}
