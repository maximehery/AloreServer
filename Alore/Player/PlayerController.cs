﻿namespace Alore.Player
{
    using System.Threading.Tasks;
    using API.Player;
    using API.Player.Models;

    public class PlayerController : IPlayerController
    {
        private readonly PlayerRepostiory _playerRepostiory;

        public PlayerController(PlayerRepostiory playerRepostiory)
        {
            _playerRepostiory = playerRepostiory;
        }

        public async Task<IPlayer> GetPlayerByIdAsync(int id) =>
            await _playerRepostiory.GetPlayerById(id);

        public async Task<IPlayer> GetPlayerBySsoAsync(string sso) =>
            await _playerRepostiory.GetPlayerBySso(sso);
    }
}