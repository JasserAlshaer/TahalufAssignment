export class DatePaginationResponse<T>{
    statusCode:number|undefined;
    message : string|undefined;
    itemsCount:number|undefined;
    items:T[] = []
}