export class DataResponseDto<T>{
    statusCode : number|undefined;
    message : string|undefined;
    entity : T|undefined;
}