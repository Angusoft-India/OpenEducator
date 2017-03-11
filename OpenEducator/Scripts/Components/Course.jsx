var Course = React.createClass({

    getInitialState: function() {
        return {
            Data: JSON.parse(this.props.Data)
        };
    },
    render: function () {
        return (<PropertyReader data={this.state.Data} />);
    }

});

var PropertyReader = React.createClass({

    getInitialState: function() {
        return {
            Data: this.props.data
        }  
    },
    render: function () {

        var PropRead = this.state.Data;

        var readProps = [];

        Object.keys(PropRead).forEach(function (key) {
            if (PropRead[key] === null || PropRead[key] === 'undefined') {
                readProps.push(<div key={key}>{key}</div>);
            } else if (typeof (PropRead[key]) == "object") {
                console.log(key + ' : ' + PropRead[key]);
                readProps.push(<div key={key}>{key}</div>);
            } else if (typeof(PropRead[key]) != "undefined") {
                readProps.push(<SingleProperty key={key} Name={key} Value={PropRead[key]} />);
            }
        });

        
        return (<div className="Properties">{readProps}</div>);
    }

});

var SingleProperty = React.createClass({

    getInitialState: function() {
        return {
            name: this.props.Name,
            value: this.props.Value
        }  
    },
    handleChange: function (event) {
        this.setState({
            value: event.target.value
        });
    },
    render: function () {

        var field = "text";
        
        switch(typeof(this.state.value)) {
            case "string": field = "text";
                break;
            case "number": field = "number";
                break;
        }

        return (<div className="SingleProperty">
            <label>{this.state.name}</label>
            <input type={field} value={this.state.value} name={this.state.name} onChange={this.handleChange} />
        </div>);
    }

});