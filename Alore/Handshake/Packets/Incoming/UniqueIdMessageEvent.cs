﻿namespace Alore.Handshake.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    public class UniqueIdMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string uniqueId = clientPacket.ReadString();
            session.UniqueId = uniqueId;
            await session.WriteAndFlushAsync(new SetUniqueIdComposer(uniqueId));
        }
    }
}