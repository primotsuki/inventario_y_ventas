import { Input, Form } from 'rsuite';
import './form.scss';

const Field = ({helperText, children, as: Component = Input,asProp, label, field, error, labelAlign=false, ...rest }) => {
    return (
      <Form.Group>
        
        <Form.ControlLabel>{label}
        {helperText && <Form.HelpText tooltip>{helperText}</Form.HelpText>}
        </Form.ControlLabel>
        
        <Component
          id={field.name}
          value={field.value}
          onChange={value => field.onChange(value)}
          as={asProp}
          {...rest}
        >
          {children}
        </Component>

        <Form.ErrorMessage show={!!error} placement="bottomStart">
          {error}
        </Form.ErrorMessage>
      </Form.Group>
    );
};

export default Field;