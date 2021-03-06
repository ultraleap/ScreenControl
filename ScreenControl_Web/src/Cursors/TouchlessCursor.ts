import { ClientInputAction } from '../ScreenControlTypes';
import { ConnectionManager } from '../Connection/ConnectionManager';

// Class: TouchlessCursor
// This class is a base class for creating custom Touchless cursors for use with ScreenControl.
//
// Override <HandleInputAction> to react to <ClientInputActions> as they are recieved.
//
// For an example of a reactive cursor, see <DotCursor>.
export abstract class TouchlessCursor {
    // Group: Variables

    // Variable: cursor
    // The HTMLElement that represents this cursor
    cursor: HTMLElement;

    // Group: Functions

    // Function: constructor
    // Registers the Cursor for updates from the <ConnectionManager>
    //
    // If you intend to make use of the <WebInputController>, make sure that _cursor has the
    // "screencontrolcursor" class. This prevents it blocking other elements from recieving events.
    constructor(_cursor: HTMLElement) {
        ConnectionManager.instance.addEventListener('TransmitInputAction', ((e: CustomEvent<ClientInputAction>) => {
            this.HandleInputAction(e.detail);
        }) as EventListener);

        this.cursor = _cursor;
    }

    // Function: UpdateCursor
    // Sets the position of the cursor, should be run after <HandleInputAction>.
    UpdateCursor(_inputAction: ClientInputAction): void {
        this.cursor.style.left = (_inputAction.CursorPosition[0] - (this.cursor.clientWidth / 2)) + "px";
        this.cursor.style.top = (window.innerHeight - (_inputAction.CursorPosition[1] + (this.cursor.clientHeight / 2))) + "px";
    }

    // Function: HandleInputAction
    // The core of the logic for Cursors, this is invoked with each <ClientInputAction> as
    // they are recieved. Override this function to implement cursor behaviour in response.
    //
    // Parameters:
    //    _inputAction - The latest input action recieved from ScreenControl Service.
    HandleInputAction(_inputAction: ClientInputAction): void {
        this.UpdateCursor(_inputAction);
    }
}