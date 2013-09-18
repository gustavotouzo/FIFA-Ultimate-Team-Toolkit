﻿using System;
using System.Net;
using System.Net.Http;
using UltimateTeam.Toolkit.Constants;

namespace UltimateTeam.Toolkit.Requests
{
    public abstract class FutRequestBase
    {
        private static readonly CookieContainer CookieContainer = new CookieContainer();

        protected readonly HttpClient HttpClient;

        protected static string PhishingToken { get; set; }

        protected static string SessionId { get; set; }

        protected FutRequestBase()
        {
            var messageHandler = new HttpClientHandler
            {
                CookieContainer = CookieContainer,
                AutomaticDecompression = DecompressionMethods.GZip
            };
            HttpClient = new HttpClient(messageHandler);
            HttpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        protected void AddCommonHeaders()
        {
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(NonStandardHttpHeaders.PhishingToken, PhishingToken);
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(NonStandardHttpHeaders.EmbedError, "true");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(NonStandardHttpHeaders.SessionId, SessionId);
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.AcceptEncoding, "gzip,deflate,sdch");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.AcceptLanguage, "en-US,en;q=0.8");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.Accept, "application/json");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.ContentType, "application/json");
            HttpClient.DefaultRequestHeaders.Referrer = new Uri("http://www.easports.com/iframe/fut/bundles/futweb/web/flash/FifaUltimateTeam.swf");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.UserAgent, "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.62 Safari/537.36");
        }
    }
}