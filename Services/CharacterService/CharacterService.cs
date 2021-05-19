using System.Collections.Generic;
using asp.net.Models;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using asp.net.Dtos.Character;
using System;
using asp.net.Data;
using Microsoft.EntityFrameworkCore;

namespace asp.net.Services.CharacterService
{
    
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context){
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
              var serviceResponse = new ServiceResponse<GetCharacterDto>();
              var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
              serviceResponse.Data =  _mapper.Map<GetCharacterDto>(dbCharacter);
           return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{
            Character character = await _context.Characters.FirstOrDefaultAsync(c=> c.Id == updatedCharacter.Id);
            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defense = updatedCharacter.Defense;
            character.Intelligense = updatedCharacter.Intelligense;
            character.Class = updatedCharacter.Class;
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }catch(Exception ex){
                serviceResponse.Success =false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
           
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
            Character character = await _context.Characters.FirstOrDefaultAsync(c=> c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
          
            }catch(Exception ex){
                serviceResponse.Success =false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
           
        }
    }
}