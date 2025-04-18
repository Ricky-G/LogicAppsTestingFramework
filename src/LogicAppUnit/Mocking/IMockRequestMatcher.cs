﻿using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace LogicAppUnit.Mocking
{
    /// <summary>
    /// Request Matcher that is used to build the request match conditions for mocking.
    /// </summary>
    public interface IMockRequestMatcher
    {
        /// <summary>
        /// Configure request matching using any HTTP method.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingAnyMethod();

        /// <summary>
        /// Configure request matching using HTTP GET.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingGet();

        /// <summary>
        /// Configure request matching using HTTP POST.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingPost();

        /// <summary>
        /// Configure request matching using HTTP PUT.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingPut();

        /// <summary>
        /// Configure request matching using HTTP PATCH.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingPatch();

        /// <summary>
        /// Configure request matching using HTTP DELETE.
        /// </summary>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingDelete();

        /// <summary>
        /// Configure request matching using one or more HTTP methods.
        /// </summary>
        /// <param name="methods">The HTTP methods to match.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher UsingMethod(params HttpMethod[] methods);

        /// <summary>
        /// Configure request matching based on the names of one or more workflow actions that sent the request.
        /// </summary>
        /// <param name="actionNames">The action names to match.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher FromAction(params string[] actionNames);

        /// <summary>
        /// Configure request matching using one or more URL absolute paths.
        /// </summary>
        /// <param name="matchType">The type of match to be used when matching the absolute paths.</param>
        /// <param name="paths">The absolute paths to match.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithPath(PathMatchType matchType, params string[] paths);

        /// <summary>
        /// Configure request matching based on the existance of a HTTP header. The value of the header is not considered in the match.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithHeader(string name);

        /// <summary>
        /// Configure request matching using a HTTP header and its value.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithHeader(string name, string value);

        /// <summary>
        /// Configure request matching using one or more content types, for example <c>application/json</c> or <c>application/xml; charset=utf-8</c>.
        /// </summary>
        /// <param name="contentTypes">The content types to match. This must be an exact match, including any media type and encoding.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithContentType(params string[] contentTypes);

        /// <summary>
        /// Configure request matching based on the existance of a query parameter. The value of the parameter is not considered in the match.
        /// </summary>
        /// <param name="name">The query parameter name.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithQueryParam(string name);

        /// <summary>
        /// Configure request matching based on a query parameter and its value.
        /// </summary>
        /// <param name="name">The query parameter name.</param>
        /// <param name="value">The query parameter value.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithQueryParam(string name, string value);

        /// <summary>
        /// Configure request matching using the request match count number, where the number of times that the request has been matched during the test execution matches <paramref name="matchCounts"/>).
        /// </summary>
        /// <param name="matchCounts">The match count numbers.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        /// <remarks>This match is the logical inverse of <see cref="WithNotMatchCount(int[])"/>.</remarks>
        IMockRequestMatcher WithMatchCount(params int[] matchCounts);

        /// <summary>
        /// Configure request matching using the request match count number, where the number of times that the request has been matched during the test execution does not match <paramref name="matchCounts"/>).
        /// </summary>
        /// <param name="matchCounts">The match count numbers.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        /// <remarks>This match is the logical inverse of <see cref="WithMatchCount(int[])"/>.</remarks>
        IMockRequestMatcher WithNotMatchCount(params int[] matchCounts);

        /// <summary>
        /// Configure request matching based on the request content (as a <see cref="String"/>) and a delegate function that determines if the request is matched.
        /// </summary>
        /// <param name="requestContentMatch">Delegate function that returns <c>true</c> if the content is matched, otherwise <c>false</c>.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithContentAsString(Func<string, bool> requestContentMatch);

        /// <summary>
        /// Configure request matching based on the JSON request content (as a <see cref="JToken"/>) and a delegate function that determines if the request is matched.
        /// </summary>
        /// <param name="requestContentMatch">Delegate function that returns <c>true</c> if the content is matched, otherwise <c>false</c>.</param>
        /// <returns>The <see cref="IMockRequestMatcher"/>.</returns>
        IMockRequestMatcher WithContentAsJson(Func<JToken, bool> requestContentMatch);
    }
}
