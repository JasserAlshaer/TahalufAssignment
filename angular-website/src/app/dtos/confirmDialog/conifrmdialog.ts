export class ConfirmDialogData{
    title :string | undefined ; 
    message:string|undefined;
    yesButtonLabel : string|undefined;
    NoButtonLabel : string|undefined;
    
    constructor(title:string|undefined, message:string|undefined,yesmessage:string|undefined,noMessage:string|undefined){
        this.title = title;
        this.message = message
        this.yesButtonLabel = yesmessage
        this.NoButtonLabel = noMessage
    }
}