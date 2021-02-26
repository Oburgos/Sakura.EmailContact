/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { AddContactDto } from '../models/add-contact-dto';
import { AddContactListDto } from '../models/add-contact-list-dto';
import { ContactDto } from '../models/contact-dto';
import { ContactListDto } from '../models/contact-list-dto';

@Injectable({
  providedIn: 'root',
})
export class ContactsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiContactsGet
   */
  static readonly ApiContactsGetPath = '/api/Contacts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ContactDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ContactDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsGet$Plain(params?: {
  }): Observable<Array<ContactDto>> {

    return this.apiContactsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ContactDto>>) => r.body as Array<ContactDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<Array<ContactDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ContactDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsGet$Json(params?: {
  }): Observable<Array<ContactDto>> {

    return this.apiContactsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ContactDto>>) => r.body as Array<ContactDto>)
    );
  }

  /**
   * Path part for operation apiContactsPost
   */
  static readonly ApiContactsPostPath = '/api/Contacts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsPost$Plain$Response(params?: {
    body?: AddContactDto
  }): Observable<StrictHttpResponse<ContactDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsPost$Plain(params?: {
    body?: AddContactDto
  }): Observable<ContactDto> {

    return this.apiContactsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ContactDto>) => r.body as ContactDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsPost$Json$Response(params?: {
    body?: AddContactDto
  }): Observable<StrictHttpResponse<ContactDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsPost$Json(params?: {
    body?: AddContactDto
  }): Observable<ContactDto> {

    return this.apiContactsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ContactDto>) => r.body as ContactDto)
    );
  }

  /**
   * Path part for operation apiContactsListsPost
   */
  static readonly ApiContactsListsPostPath = '/api/Contacts/lists';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsPost$Plain$Response(params?: {
    body?: AddContactListDto
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsPost$Plain(params?: {
    body?: AddContactListDto
  }): Observable<ContactListDto> {

    return this.apiContactsListsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsPost$Json$Response(params?: {
    body?: AddContactListDto
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsPost$Json(params?: {
    body?: AddContactListDto
  }): Observable<ContactListDto> {

    return this.apiContactsListsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

  /**
   * Path part for operation apiContactsListsListIdContactsPost
   */
  static readonly ApiContactsListsListIdContactsPostPath = '/api/Contacts/lists/{listId}/contacts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsListIdContactsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsListIdContactsPost$Plain$Response(params: {
    listId: number;
    body?: Array<number>
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsListIdContactsPostPath, 'post');
    if (params) {
      rb.path('listId', params.listId, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsListIdContactsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsListIdContactsPost$Plain(params: {
    listId: number;
    body?: Array<number>
  }): Observable<ContactListDto> {

    return this.apiContactsListsListIdContactsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsListIdContactsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsListIdContactsPost$Json$Response(params: {
    listId: number;
    body?: Array<number>
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsListIdContactsPostPath, 'post');
    if (params) {
      rb.path('listId', params.listId, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsListIdContactsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiContactsListsListIdContactsPost$Json(params: {
    listId: number;
    body?: Array<number>
  }): Observable<ContactListDto> {

    return this.apiContactsListsListIdContactsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

  /**
   * Path part for operation apiContactsListsIdGet
   */
  static readonly ApiContactsListsIdGetPath = '/api/Contacts/lists/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsListsIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsListsIdGet$Plain(params: {
    id: number;
  }): Observable<ContactListDto> {

    return this.apiContactsListsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiContactsListsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsListsIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ContactListDto>> {

    const rb = new RequestBuilder(this.rootUrl, ContactsService.ApiContactsListsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ContactListDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiContactsListsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiContactsListsIdGet$Json(params: {
    id: number;
  }): Observable<ContactListDto> {

    return this.apiContactsListsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ContactListDto>) => r.body as ContactListDto)
    );
  }

}
