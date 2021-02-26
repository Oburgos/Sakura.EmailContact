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

import { AddCampaignDto } from '../models/add-campaign-dto';
import { CampaignDto } from '../models/campaign-dto';

@Injectable({
  providedIn: 'root',
})
export class CampaignsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiCampaignsPost
   */
  static readonly ApiCampaignsPostPath = '/api/Campaigns';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiCampaignsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiCampaignsPost$Plain$Response(params?: {
    body?: AddCampaignDto
  }): Observable<StrictHttpResponse<CampaignDto>> {

    const rb = new RequestBuilder(this.rootUrl, CampaignsService.ApiCampaignsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CampaignDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiCampaignsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiCampaignsPost$Plain(params?: {
    body?: AddCampaignDto
  }): Observable<CampaignDto> {

    return this.apiCampaignsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CampaignDto>) => r.body as CampaignDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiCampaignsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiCampaignsPost$Json$Response(params?: {
    body?: AddCampaignDto
  }): Observable<StrictHttpResponse<CampaignDto>> {

    const rb = new RequestBuilder(this.rootUrl, CampaignsService.ApiCampaignsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CampaignDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiCampaignsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiCampaignsPost$Json(params?: {
    body?: AddCampaignDto
  }): Observable<CampaignDto> {

    return this.apiCampaignsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CampaignDto>) => r.body as CampaignDto)
    );
  }

}
