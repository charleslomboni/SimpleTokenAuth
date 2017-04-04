﻿using System;
using System.Linq;
using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Library;
using SimpleTokenAuth.Repository;
using Xunit;

namespace SimpleTokenAuth.Tests.UnitTests {
    /// <summary>
    /// Summary description for AccountRepositoryTests
    /// </summary>
    public class AccountRepositoryTests {

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get one account
            var account = accountRepository.GetAccount(login);

            //Verifiy if is null
            Assert.NotNull(account);
            //Verifiy if is null
            Assert.NotNull(account.TokenData);
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Login));
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Password));
            //Verifiy if are equal
            Assert.Equal(account.Login, login);
            //Verifiy if are equal
            Assert.Equal(account.Password, password);
            //Verifiy if are equal
            Assert.Equal(account.TokenData.Token, tokenData.Token);
        }

        [Fact]
        public void GetAccountFail() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get invalid account 
            var account = accountRepository.GetAccount("fff");

            //verify if is null
            Assert.Null(account);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountWithLoginAndTokenSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get one account
            var account = accountRepository.GetAccount(login, tokenData.Token);

            //Verifiy if is null
            Assert.NotNull(account);
            //Verifiy if is null
            Assert.NotNull(account.TokenData);
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Login));
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Password));
            //Verifiy if are equal
            Assert.Equal(account.Login, login);
            //Verifiy if are equal
            Assert.Equal(account.Password, password);
            //Verifiy if are equal
            Assert.Equal(account.TokenData.Token, tokenData.Token);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountWithPassowrdValidateSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get one account
            var result = accountRepository.PasswordValidate(login, password);

            //Verifiy if is null
            Assert.NotNull(result);
            //Verifiy if is null
            Assert.True(result);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountAllAccountsSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get one account
            var result = accountRepository.GetAllAccounts();

            //Verifiy if is null
            Assert.NotNull(result);
                
            //convert type list to array
            var authAccounts = result as AuthAccount[] ?? result.ToArray();

            //Verifiy if is true
            Assert.True(authAccounts.Any());
            //Verifiy if is true
            Assert.True(authAccounts.Count() == accountList.AuthAccounts.Count);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountAllAccountsWithValidtokenSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData() {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList() {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount() { Login = "def", Password = "456", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount() { Login = "fgh", Password = "789", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount() { Login = login, Password = password, TokenData = tokenData}},
                    {"ijl", new AuthAccount() { Login = "ijl", Password = "000", TokenData = new TokenData(){ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

            //Account repository
            var accountRepository = new AccountRepository(accountList);
            //Get one account
            var result = accountRepository.GetAllAccountsWithValidToken(simpleTokenLibrary.Validation);

            //Verifiy if is null
            Assert.NotNull(result);

            //convert type list to array
            var authAccounts = result as AuthAccount[] ?? result.ToArray();

            //Verifiy if is true
            Assert.True(authAccounts.Any());
            //Verifiy if is true
            Assert.True(authAccounts.Count() == accountList.AuthAccounts.Count);
        }
    }
}