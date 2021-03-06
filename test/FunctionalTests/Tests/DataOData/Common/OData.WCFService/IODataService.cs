﻿//---------------------------------------------------------------------
// <copyright file="IODataService.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.Test.Taupo.OData.WCFService
{
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    /// <summary>
    /// Contract for the OData over WCF Service
    /// </summary>
    [ServiceContract]
    public interface IODataService
    {
        /// <summary>
        /// This is the entry point into the OData server which processes query requests for feed or entry data.
        /// </summary>
        /// <param name="requestUri">The request URI to process and return results for.</param>
        /// <returns>A stream containing the results of parsing the <paramref name="requestUri"/>against the data store and return results for the same.</returns>
        [WebGet(UriTemplate = "/OData/{requestUri}")]
        Stream GetFeedOrEntry(string requestUri);

        /// <summary>
        /// This is the entry point into the OData server which processes query requests for property data.
        /// </summary>
        /// <param name="uriPart1">The entry part of the request URI.</param>
        /// <param name="uriPart2">The property part of the request URI.</param>
        /// <returns>A stream containing the results of parsing the query against the data store and return results for the same.</returns>
        [WebGet(UriTemplate = "/OData/{uriPart1}/{uriPart2}")]
        Stream GetProperty(string uriPart1, string uriPart2);

        /// <summary>
        /// This is the entry point into the OData server which returns the Service Document.
        /// </summary>
        /// <returns>A stream containing the Service Document based on the sets exposed by the backing data store.</returns>
        [WebGet(UriTemplate = "/OData/")]
        Stream GetServiceDocument();

        /// <summary>
        /// This is the entry point into the OData server which returns the OData Metadata document.
        /// </summary>
        /// <returns>A stream containing the Metadata document based on the sets and types exposed by the backing data store.</returns>
        [WebGet(UriTemplate = "/OData/$metadata")]
        Stream GetMetadataDocument();

        /// <summary>
        /// This is the entry point into the OData server for requests to create a new entry.
        /// </summary>
        /// <param name="messageBody">Stream containing the new entry to insert into the backing data store.</param>
        /// <param name="requestUri">The request URI to parse for the target entity set.</param>
        /// <returns>If successful, a stream containg the new entry. Otherwise, an error.</returns>
        [WebInvoke(UriTemplate = "/OData/{requestUri}", Method = "POST")]
        Stream CreateEntry(Stream messageBody, string requestUri);

        /// <summary>
        /// This is the entry point into the OData server for requests to update an existing entry.
        /// </summary>
        /// <param name="messageBody">The body of the message, containing the updated entry values.</param>
        /// <param name="requestUri">The request URI to parse for the target entry.</param>
        /// <returns>If successful, a stream containg the updated entry. Otherwise, an error.</returns>
        [WebInvoke(UriTemplate = "/OData/{requestUri}", Method = "PUT")]
        Stream UpdateEntry(Stream messageBody, string requestUri);

        /// <summary>
        /// This is the entry point into the OData server for requests to update a property value.
        /// </summary>
        /// <param name="messageBody">The body of the message, containing the updated property value.</param>
        /// <param name="uriPart1">The entry part of the request URI.</param>
        /// <param name="uriPart2">The property part of the request URI.</param>
        /// <returns>If successful, a stream containg the updated entry. Otherwise, an error.</returns>
        [WebInvoke(UriTemplate = "/OData/{uriPart1}/{uriPart2}", Method = "PUT")]
        Stream UpdateProperty(Stream messageBody, string uriPart1, string uriPart2);

        /// <summary>
        /// This is the entry point into the OData server for requests to delete an existing entry.
        /// </summary>
        /// <param name="requestUri">The request URI to parse for the target entry.</param>
        /// <returns>If successful, an empty stream. Otherwise, an error.</returns>
        [WebInvoke(UriTemplate = "/OData/{requestUri}", Method = "DELETE")]
        Stream DeleteEntry(string requestUri);
    }
}
