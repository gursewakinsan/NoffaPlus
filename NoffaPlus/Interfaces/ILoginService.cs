﻿using System.Threading.Tasks;

namespace NoffaPlus.Interfaces
{
	public interface ILoginService
	{
		Task<Models.LoginResponse> LoginAsync(Models.LoginRequest request);
		Task<Models.InterAppSessionResponse> LoginWithSessionAsync(Models.InterAppSessionRequest request);
	}
}
