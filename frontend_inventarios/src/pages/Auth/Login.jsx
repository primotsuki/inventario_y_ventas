import React, {useState} from 'react';
import { useForm, Controller } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import { yupResolver } from '@hookform/resolvers/yup';
import { loginUser } from '../../api/auth/auth.requests';
import Field from '../../components/Form/Field';
// import logoIcon from '../../assets/logo_aisem.png';
import { Message, Loader, Input } from 'rsuite';
import { Button,Form } from 'rsuite';
import * as Yup from 'yup';

const validationSchema = Yup.object().shape({
    username: Yup.string().required('El nombre de usuario es necesario'),
    password: Yup.string().required('La contraseña es requerida')
});

const Login = () => {

    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const defaultValues = {

    };

    const {
        control,
        handleSubmit,
        formState: {errors}
    } = useForm({defaultValues, resolver: yupResolver(validationSchema)});

    const saveUserInfo = (data) =>{
        localStorage.setItem('token',data.token);
        delete data.token;
        localStorage.setItem('userInfo',JSON.stringify(data));
    };
    const onSubmit = async (data) => {
        try {
            setError(null);
            setLoading(true);
            const user = await loginUser(data);
            saveUserInfo(user.data);
            navigate('/app/dashboard');
        } catch (error) {
            setLoading(false);
            setError(error.response.data.message)
        }
    }
    return (
        <div className='login-card'>
            {/* <img src={logoIcon}  width={300}/> */}
            <div style={{textAlign:'center', padding: '40px 0px'}}>
                <h4>SISTEMA DE INVENTARIO Y VENTAS</h4>
            </div>
            <div className='login-form-card'>

                {
                    error && <Message showIcon type='error'>
                        <strong>Error!</strong> {error}
                    </Message>
                }
                <Form className='form-config-options' onSubmit={handleSubmit(onSubmit)}>
                    <Controller
                        name="username"
                        control={control}
                        render={({field, fieldState})=>(
                            <Field field={field} error={errors[field.name]?.message} placeholder="Nombre de usuario" size="lg"/>
                        )}
                    />
                    <Controller
                        name="password"
                        control={control}
                        render={({ field, fieldState }) => (
                        <Field field={field} error={errors[field.name]?.message} placeholder="Contraseña" type="password" size="lg"/>
                        )}
                    />

                    <Button appearance="primary" type="submit" block>
                        Ingresar
                    </Button>
                </Form>
            </div>
            {
            loading && <Loader backdrop content="loading..." vertical />
            }
        </div>
    )
}

export default Login;